using System;
using Android.App;
using Android.Hardware;
using Android.Runtime;
using DizzyProject.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(StepCounter_Adroid))]
namespace DizzyProject.Droid
{
    public class StepCounter_Adroid : Activity, ISensorEventListener, IStepCounter
    {
        public event EventHandler CountChanged;
        private float oldX = 0;
        private float oldY = 0;
        private float oldZ = 0;

        private int _count;
        public int Count
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

        public void StartSensor()
        {
            SensorManager sm = (SensorManager)MainActivity.Activity.GetSystemService(SensorService);

            if (sm.GetSensorList(SensorType.Accelerometer).Count != 0)
            {
                Sensor s = sm.GetDefaultSensor(SensorType.Accelerometer);
                sm.RegisterListener(this, s, SensorDelay.Normal);
            }
        }

        public void OnSensorChanged(SensorEvent e)
        {
            float newX = e.Values[0];
            float newY = e.Values[1];
            float newZ = e.Values[2];

            if (oldX != newX || oldY != newY || oldZ != newZ)
            {
                Count = Count + 1;
            }

            oldX = e.Values[0];
            oldY = e.Values[1];
            oldZ = e.Values[2];
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            throw new NotImplementedException();
        }
    }
}