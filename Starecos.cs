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

    public record NevalidatStareCos:IStarecos
    {
        public NevalidatStareCos(Client client, List<Produs> produse)
        {
            Client = client;
            Produse = produse;

        }
        public Client Client; 
        public List<Produs> Produse; 
    }
    public record GolStareCos:IStarecos
    {
         GolStareCos(Client client, List<Produs> produse)
        {
                Client = client;
                Produse = produse;

        }
        public Client Client;
        public List<Produs> Produse; 
    }
    public record ValidatStareCos:IStarecos
    {
        public ValidatStareCos(Client client, List<Produs> produse)
        {
            Client = client;
            Produse = produse;
        }
        public Client Client {get; }
        public List<Produs> Produse{get; }
        }
        public record PlatitStareCos:IStarecos
        {
            PlatitStareCos(Client client, List<Produs> produse, DateTime TimpulPlata)
            {
                Client = client;
                Produse = produse;
            }
            public Client Client;
            public List<Produs> Produse; 
        }


       // public record UnvalidatedExamGrades(IReadOnlyCollection<UnvalidatedStudentGrade> GradesList) : IExamGrades;

       // public record InvalidatedExamGrades(IReadOnlyCollection<UnvalidatedStudentGrade> GradesList, string reason) : IExamGrades;

       // public record ValidatedExamGrades(IReadOnlyCollection<ValidatedStudentGrade> GradesList) : IExamGrades;

       // public record PublishedExamGrades(IReadOnlyCollection<ValidatedStudentGrade> GradesList, DateTime PublishedDate) : IExamGrades;
    }
}
