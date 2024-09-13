using System;

namespace CourseWork.Source.Entities
{
    /// <summary>
    /// Класс, представляющий информацию о человеке
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Номер телефона (первичный ключ в базе данных)
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Роль человека (поэт или критик)
        /// </summary>
        public Roles Role { get; set; }

        /// <summary>
        /// Перечисление ролей, соответствует таблицам базы данных
        /// </summary>
        public enum Roles
        {
            /// <summary>
            /// Поэт
            /// </summary>
            Poet,

            /// <summary>
            /// Критик
            /// </summary>
            Critic,
        }
    }
}