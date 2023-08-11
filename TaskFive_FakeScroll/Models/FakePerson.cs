﻿using Bogus;
using Bogus.DataSets;

namespace TaskFive_FakeScroll.Models
{
    public class FakePerson : IHasRandomizer, IHasContext
    {
        internal Dictionary<string, object> context = new Dictionary<string, object>();

        Dictionary<string, object> IHasContext.Context => this.context;

        protected Name DsName { get; set; }
        protected Date DsDate { get; set; }
        protected PhoneNumbers DsPhoneNumbers { get; set; }
        protected Bogus.DataSets.Address DsAddress { get; set; }

        /// <summary>
        /// Creates a new Person object.
        /// </summary>
        /// <param name="locale">The locale to use. Defaults to 'en'.</param>
        /// <param name="seed">The seed used to generate person data. When a <paramref name="seed"/> is specified,
        /// the Randomizer.Seed global static is ignored and a locally isolated derived seed is used to derive randomness.
        /// However, if the <paramref name="seed"/> parameter is null, then the Randomizer.Seed global static is used to derive randomness.
        /// </param>
        public FakePerson(string locale = "en", int? seed = null, int num = 0)
        {
            this.GetDataSources(locale);
            if (seed.HasValue)
            {
                this.Random = new Randomizer(seed.Value);
            }
            this.Populate();
            Num=num;
        }

        internal FakePerson(Randomizer randomizer, string locale = "en", int num = 0)
        {
            this.GetDataSources(locale);
            this.Random = randomizer;
            this.Populate();
            Num=num;
        }

        private void GetDataSources(string locale)
        {
            this.DsName = this.Notifier.Flow(new Name(locale));
            this.DsPhoneNumbers = this.Notifier.Flow(new PhoneNumbers(locale));
            this.DsAddress = this.Notifier.Flow(new Bogus.DataSets.Address(locale));
        }

        protected internal virtual void Populate()
        {
            this.Gender = this.Random.Enum<Name.Gender>();
            this.FirstName = this.DsName.FirstName(this.Gender);
            this.LastName = this.DsName.LastName(this.Gender);
            this.FullName = $"{this.FirstName} {this.LastName}";

            this.Phone = this.DsPhoneNumbers.PhoneNumber();

            this.Address = new Address
            {
                Street = this.DsAddress.StreetAddress(),
                Suite = this.DsAddress.SecondaryAddress(),
                City = this.DsAddress.City(),
                State = this.DsAddress.State(),
                ZipCode = this.DsAddress.ZipCode(),
            };
        }

        protected SeedNotifier Notifier = new SeedNotifier();

        private Randomizer randomizer;

        public Randomizer Random
        {
            get => this.randomizer ?? (this.Random = new Randomizer());
            set
            {
                this.randomizer = value;
                this.Notifier.Notify(value);
            }
        }

        SeedNotifier IHasRandomizer.GetNotifier()
        {
            return this.Notifier;
        }

        public Name.Gender Gender;
        public int Num { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
    }
}
