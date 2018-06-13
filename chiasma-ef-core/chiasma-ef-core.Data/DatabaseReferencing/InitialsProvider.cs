using System;
using Repositories;

namespace DatabaseReferencing
{
    public class InitialsProvider
    {
        const string InitialsEnvVar = "INITIALS";

        private readonly IEnvironmentRepository repository;

        public InitialsProvider(IEnvironmentRepository repository)
        {
            this.repository = repository;
        }

        public string ProvideInitials()
        {
            var devInitials = repository.GetValue(InitialsEnvVar);
            if (String.IsNullOrEmpty(devInitials))
            {
                throw new Exception(InitialsEnvVar);
            }
            return devInitials;
        }
    }
}
