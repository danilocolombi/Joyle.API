using System;
using System.Collections.Generic;

namespace Joyle.Games.Application.Cardashians.GetCardashian
{
    public class CardashianDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<CardashianCardDto> Cards { get; set; }
    }

    public class CardashianCardDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public Guid CardashianId { get; set; }
    }
}
