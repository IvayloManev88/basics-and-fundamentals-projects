namespace P01_HospitalDatabase.Common
{
    public class EntityValidationConstants
    {
        public class Patient
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int PatientAddressLength = 250;
            public const int PatientEmailLength = 80;

        }
        public class Visitation
        {
            public const int VisitationCommentMaxLength = 250;
           

        }

        public class Diagnose
        {
            public const int DiagnoseNameMaxLength = 50;
            public const int DiagnoseCommentMaxLength = 250;

        }

        public class Medicament
        {
            public const int MedicamentNameMaxLength = 50;
            

        }

        public class Doctor
        {
            public const int DoctorNameMaxLength = 100;
            public const int DoctorSpecialtyMaxLength = 100;

        }
    }
}
