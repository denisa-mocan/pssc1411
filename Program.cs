using System;
using System.Collections.Generic;
using static PSSC_S3.StareCos;
using static PSSC_S3.Cantitate;

namespace PSSC_S3
{
    public class Program{
        static void Main(string[] args)
        {
            Produs produs1 = new Produs(new Cantitate.CantitateKg(1), "cod1", "adresa");
            Produs produs2 = new Produs(new Cantitate.CantitateUnitati(39), "cod2", "adresa1");
            Produs produs3 = new Produs(new Cantitate.CantitateKg(1), "cod3", "adresa2");
            Client client1 = new Client("Iulia", "Jubea", "1234");
            List<Produs> Produse=new List<Produs>();
            Produse.Add(produs1);


            PublicareComandaCommand command = new (client1, Produse);
            PublicareComandaWorkflow workflow = new PublicareComandaWorkflow();

            var result = workflow.Execute(command, (var)=> true);

            result.Match(
                    whenComandaPublicareFailEvent: @event =>
                    {
                        Console.WriteLine($"Publish failed: {@event.Reason}");
                        return @event;
                    },
                    whenComandaPublicareSucceedEvent: @event =>
                    {
                        Console.WriteLine($"Publish succeeded.");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
                );

            Console.WriteLine("Hello World!");
        //     Console.WriteLine("Hello, World!");

       
        //     Console.WriteLine(produs1);
        //     Console.WriteLine(produs2);
        //     Console.WriteLine(produs3);
        //    
        //     
        //     //CosNevalidat cos1 = new CosNevalidat(client1, Produse);
        //     NevalidatStareCos comandanevalidata1 = new (client1, Produse);

        //    // IStarecos result = IdentificareGol(comanda1);
        //     IStarecos result = ValidareStareCos(comandanevalidata1);

        //     result.Match(
        //         whenNevalidatStareCos: unvalidatedResult => comandanevalidata1,
        //         whenGolStareCos: golResult => golResult,
        //         whenPlatitStareCos: platitResult => platitResult,
        //         whenValidatStareCos: validatResult => PlataComenzii(validatResult)
        //     );
            //Console.WriteLine(comandanevalidata1.client.nume);

           // Console.WriteLine(cos1.Produse);
           // Console.WriteLine(cos1.Client);
            // produs1.adresa="jskdhfk";
        }

        // private static IStarecos IdentificareGol(NevalidatStareCos comanda)=> 
        //    comanda.Produse.Count==0? 
        //     new GolStareCos(new Client(), new List<Produs>())
        //     : new ValidatStareCos(new Client("Iulia", "Jubea", "1234"), new List<Produs>());

        // private static IStarecos ValidareStareCos(NevalidatStareCos comandanevalidata)=> 
        // new ValidatStareCos(new Client("Iulia", "Jubea", "1234"), new List<Produs>());

        // private static IStarecos PlataComenzii(ValidatStareCos comandavalidata)=> 
        // new PlatitStareCos(new Client("Iulia", "Jubea", "1234"), new List<Produs>(), DateTime.Now);

       // private static IStarecos ValidareStareCos(NevalidatStareCos cos)=> 
    }
}