using static Android.Gms.Common.Apis.GoogleApiClient;
using System;
using Android.OS;
using Android.Test.Mock;
using Android.Gms.Fitness;
using Android.Gms.Fitness.Data;
using Android.Gms.Fitness.Request;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Fitness.Result;
using Java.Lang;
using Java.Util.Concurrent;
using static Android.OS.AsyncTask;
using Xamarin.Forms;
using DizzyProject.Droid;
using Android.Content;

[assembly: Dependency(typeof(Step_Android))]
namespace DizzyProject.Droid
{
    public class Step_Android : Java.Lang.Object, DizzyProject.IStep, IOnDataPointListener, IOnConnectionFailedListener, IConnectionCallbacks
    {
        private const int REQUEST_OAUTH = 1;
        private GoogleApiClient _client;
        private bool _authInProgress;

        public event EventHandler CountChanged;

        private int? _count;
        public int? Count
        {
            get
            {
                return _count;
            }
            private set
            {
                _count = value;
                CountChanged(this, null);
            }
        }

        public Step_Android()
        {
            _count = null;
            _authInProgress = false;
        }

        public void Connect()
        {
            _client = new Builder(Forms.Context)
                .AddApi(FitnessClass.SENSORS_API)
                .AddScope(new Scope(Scopes.FitnessActivityRead))
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .Build();

            _client.Connect();
        }

        public void OnConnected(Bundle connectionHint)
        {
            DataSourcesRequest request = new DataSourcesRequest.Builder()
                .SetDataTypes(DataType.TypeStepCountCumulative)
                .SetDataSourceTypes(DataSource.TypeRaw)
                .Build();

            IResultCallback callback = new ResultCallback<DataSourcesResult>(OnResult);

            FitnessClass.SensorsApi.FindDataSources(_client, request)
                .SetResultCallback(callback);
        }

        private void OnResult(DataSourcesResult result)
        {
            foreach (DataSource source in result.DataSources)
            {
                if (source.DataType.Equals(DataType.TypeStepCountCumulative))
                {
                    SensorRequest request = new SensorRequest.Builder()
                        .SetDataSource(source)
                        .SetDataType(DataType.TypeStepCountCumulative)
                        .SetSamplingRate(1, TimeUnit.Seconds)
                        .Build();
                    
                    FitnessClass.SensorsApi.Add(_client, request, this);
                }
            }
        }

        public void OnConnectionSuspended(int cause)
        {
            throw new NotImplementedException("Connection Suspended");
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            if (!_authInProgress)
            {
                try
                {
                    _authInProgress = true;
                    result.StartResolutionForResult(Forms.Context as Android.App.Activity, REQUEST_OAUTH);
                }
                catch (IntentSender.SendIntentException) {}
            }
        }

        public void OnDataPoint(DataPoint dataPoint)
        {
            foreach (Field field in dataPoint.DataType.Fields)
                Count = dataPoint.GetValue(field).AsInt();
        }
    }
}