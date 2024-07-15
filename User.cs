namespace osu_launcher
{
    public class Profile
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double? ScoreMeter { get; set; } = null;
        public int? MeterStyle { get; set; } = null;
        public int? Width { get; set; } = null;
        public int? Height { get; set; } = null;
        public bool? Fullscreen { get; set; } = null;
        public int? VolumeMaster { get; set; } = null;
        public int? VolumeEffect { get; set; } = null;
        public int? VolumeMusic { get; set; } = null;
        public bool ChangeVolume { get; set; } = false;
        public int? Offset { get; set; } = null;
        public string Skin { get; set; } = null;
        public bool ChangeSkin { get; set; } = false;
    }
}
