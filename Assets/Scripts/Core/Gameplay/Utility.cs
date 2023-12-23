namespace Asteroids.Core.Gameplay
{
    public static class Utility
    {
        public static float NormalizeAngle(float angle)
        {
            angle %= 360;

            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }
    }
}
