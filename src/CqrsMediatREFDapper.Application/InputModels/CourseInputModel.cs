﻿using System;

namespace CqrsMediatREFDapper.Application.InputModels
{
    public sealed class CourseInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Video { get; set; }
    }
}
