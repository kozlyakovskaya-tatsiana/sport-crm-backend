namespace SelfFit.Identity.Authorization
{
    public static class Policy
    {
        public const string ForAdminOnly = "ForAdminOnly";
        public const string ForInstructorOnly = "ForInstructorOnly";
        public const string ForAdminAndInstructor = "ForAdminAndInstructorOnly";
    }
}
