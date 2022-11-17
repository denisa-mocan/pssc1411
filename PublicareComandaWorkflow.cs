using static PSSC_S3.PublicareComandaEvent;
using System;
using static PSSC_S3.StareCos;
using static PSSC_S3.ComandaOperation;

namespace PSSC_S3
{
    public class PublicareComandaWorkflow
    {
       public IPublicareComandaEvent Execute(PublicareComandaCommand command, Func<int, bool> checkProdusExists)
       {
         NevalidatStareCos comandanevalidata1 = new (command.InputClient, command.InputProduse);

           // IStarecos result = IdentificareGol(comanda1);
        IStarecos comanda = ValidareComanda(checkProdusExists, comandanevalidata1);
        comanda = CalcularePretFinal(comanda);
        comanda = PublicareComanda(comanda);

        return comanda.Match(
                whenNevalidatStareCos: unvalidatedComanda => new ComandaPublicareFailEvent("Stare invalida") as IPublicareComandaEvent,
                whenGolStareCos: golComanda => new ComandaPublicareFailEvent("Cosul este gol"),
              //  whenValidatStareCos: validatComanda => new ComandaPublicareFailEvent("Cos neplatit"),
                whenValidatStareCos:  validatResult => new ComandaPublicareSucceedEvent()
        
                  //  whenValidatedExamGrades: validatedGrades => new ExamGradesPublishFaildEvent("Unexpected validated state"),
                  //  whenCalculatedExamGrades: calculatedGrades => new ExamGradesPublishFaildEvent("Unexpected calculated state"),
                   // whenPublishedExamGrades: publishedGrades => new ExamGradesPublishScucceededEvent(publishedGrades.Csv, publishedGrades.PublishedDate)
                );


       }
    }
}