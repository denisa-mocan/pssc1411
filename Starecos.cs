using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC_S3
{
    [AsChoice]
    public static partial class StareCos
    {
        public interface IStarecos { }

        public record NevalidatStareCos(Client client, List<Produs> Produse):IStarecos;
        public record GolStareCos(Client client, List<Produs> Produse):IStarecos;
        public record ValidatStareCos(Client client, List<Produs> Produse):IStarecos;
        public record PlatitStareCos(Client client, List<Produs> Produse, DateTime TimpulPlata):IStarecos;


       // public record UnvalidatedExamGrades(IReadOnlyCollection<UnvalidatedStudentGrade> GradesList) : IExamGrades;

       // public record InvalidatedExamGrades(IReadOnlyCollection<UnvalidatedStudentGrade> GradesList, string reason) : IExamGrades;

       // public record ValidatedExamGrades(IReadOnlyCollection<ValidatedStudentGrade> GradesList) : IExamGrades;

       // public record PublishedExamGrades(IReadOnlyCollection<ValidatedStudentGrade> GradesList, DateTime PublishedDate) : IExamGrades;
    }
}
