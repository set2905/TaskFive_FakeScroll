﻿using Bogus;
using System.Text;

namespace TaskFive_FakeScroll.Services.Interfaces
{
    public interface IErrorGenerationService
    {
        public Action<StringBuilder, Randomizer, string?>[] ErrorMethods { get; }
        public void ApplyRandomErrors(double frequency, int seed, string? locale, params StringBuilder[] applyTo);
    }
}
