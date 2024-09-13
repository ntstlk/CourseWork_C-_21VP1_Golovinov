using System;

namespace CourseWork.Source.Entities
{
    /// <summary>
    /// Класс, представляющий стихотворение
    /// </summary>
    internal class Poem
    {
        /// <summary>
        /// Номер телефона поэта
        /// </summary>
        public string PoetPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Номер телефона критика
        /// </summary>
        public string CriticPhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Дата и время загрузки стихотворения
        /// </summary>
        public DateTime Uploaded { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Текст стихотворения
        /// </summary>
        public string TextData { get; set; } = string.Empty;
    }
}