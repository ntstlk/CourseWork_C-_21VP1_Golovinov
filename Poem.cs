using System;

namespace CourseWork.Source.Entities
{
    internal class Poem
    {
        public string PoetPhoneNumber { get; set; } = string.Empty;
        public string CriticPhoneNumber { get; set; } = string.Empty;
        public DateTime Uploaded { get; set; } = DateTime.MinValue;
        public string TextData { get; set; } = string.Empty;
    }
}
