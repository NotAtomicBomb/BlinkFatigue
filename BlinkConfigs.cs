using Exiled.API.Interfaces;

namespace BlinkFatigue
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public float decreaseRate { get; set; } = 0.75f;
        public float maxBlinkTime { get; set; } = 3.5f;
        public float minBlinkTime { get; set; } = 2.5f;
        public float minReworkBlinkTime { get; set; } = 1.5f;
        public float reworkAddMin { get; set; } = 0.35f;
        public float reworkAddMax { get; set; } = 0.45f;

        

        
    }
}
