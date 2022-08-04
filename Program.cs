using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = Conexão.GetService();

            Console.WriteLine("Seja bem vindo, iremos seguir com o cadastro da conta!");
            Console.WriteLine("Por favor informe o nome da Conta");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual o CNPJ?");
            string cnpj = Console.ReadLine();

            Console.WriteLine("Qual o telefone principal?");
            string telefone = Console.ReadLine();

            Console.WriteLine("Qual o seu email?");
            string email = Console.ReadLine();

            Console.WriteLine("Qual foi o seu faturamento anual do ano passado?");
            decimal faturamento = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Qual o porte da empresa? 1 - Pequeno 2 - Média 3 - Grande");
            int porte = Convert.ToInt32(Console.ReadLine());

           /* Console.WriteLine("Qual o seu continente ?");
            Console.WriteLine("1 - Americano?");
            Console.WriteLine("2 - Asia?");
            Console.WriteLine("3 - Áfricano?");
            Console.WriteLine("4 - Europeu?");
            Console.WriteLine("5 - Oceania?");
            Console.WriteLine("6 -  Antártida?");
            int cont = Convert.ToInt32(Console.ReadLine());


            string continente = null;
            if (cont == 1)
            {
                continente = "Americano";
            }
            else if (cont == 2)
            {
                continente = "Ásia";
            }
            else if (cont == 3)
            {
                continente = "Africano";
            }
            else if (cont == 4)
            {
                continente = "Europeu";
            }
            else if (cont == 5)
            {
                continente = "Oceania";
            }
            else if (cont == 6)
            {
                continente = "Antártida";
            }
            else
            {
                Console.WriteLine("Valor invalido, tente novamente");
            }*/

            Entity conta = new Entity("account");

            conta["name"] = nome.ToString();
            conta["la_cnpj"] = cnpj.ToString();
            conta["telephone1"] = telefone.ToString();
            conta["emailaddress1"] = email.ToString();
            conta["la_faturamentoanual"] = new Money(faturamento);
            conta["la_portedaempresa"] = new OptionSetValue(porte);
           // conta["la_continente"] = new EntityReference("la_name", continente);

            Guid accountId = service.Create(conta);

            Console.WriteLine("Você deseja criar um contato para essa conta? (S/N)");
            string resposta = Console.ReadLine();
            string upresposta = resposta.ToUpper();
            if (upresposta == "S")
            {

                Console.WriteLine("Por favor informe o primeiro nome do contato");
                string primeironome = Console.ReadLine();

                Console.WriteLine("Por favor informe o segundo nome do contato");
                string segundonome = Console.ReadLine();

                Console.WriteLine("Qual o CPF?");
                string CPF = Console.ReadLine();

                Console.WriteLine("Qual o email do contato?");
                string emailcontato = Console.ReadLine();

                Console.WriteLine("Qual o cargo?");
                string cargo = Console.ReadLine();

                Console.WriteLine("Qual o sexo?");
                Console.WriteLine("1 - Masculino?");
                Console.WriteLine("2 - Feminino");
                int sexo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Qual o seu limite de credito ??");
                decimal limitecredito = Convert.ToDecimal(Console.ReadLine());




                Entity contato = new Entity("contact");


                contato["firstname"] = primeironome.ToString();
                contato["lastname"] = segundonome.ToString();
                contato["jobtitle"] = cargo.ToString();
                contato["gendercode"] = new OptionSetValue(sexo);
                contato["emailaddress1"] = emailcontato.ToString();
                contato["creditlimit"] = new Money(limitecredito);
                contato["parentcustomerid"] = new EntityReference("account", accountId);

                service.Create(contato);

            }
            else if (upresposta == "N")
            {
                Environment.Exit(0);
            }
            else
            {
                return;
            }

        }
    }
}
