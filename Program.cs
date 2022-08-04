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

            string cnpjconta = null;
            bool valida = false;
            while (valida == false)
            {
                Console.WriteLine("Qual o CNPJ?");
                cnpjconta = Console.ReadLine();
                var v = ValidacoesLibrary.Validacoes.VerificaCnpj(cnpjconta);

                if (v != false)
                {
                    valida = true;
                }
                else
                {
                    Console.WriteLine("CNPJ invalido, favor preencher novamente!");
                }
            }
            Console.WriteLine("Qual o telefone principal?");
            string telefone = Console.ReadLine();

            Console.WriteLine("Qual o seu email?");
            string email = Console.ReadLine();

            Console.WriteLine("Qual foi o seu faturamento anual do ano passado?");
            decimal faturamento = Convert.ToDecimal(Console.ReadLine());

            int porte = 0;
            valida = false;
            while (valida == false)
            {
                Console.WriteLine("Qual o porte da empresa?");
                Console.WriteLine("1 - Pequeno");
                Console.WriteLine("2 - Média");
                Console.WriteLine("3 - Grande");
                porte = Convert.ToInt32(Console.ReadLine());
                if (porte == 1 || porte == 2 || porte == 3)
                {
                    valida = true;
                }
                else
                {
                    Console.WriteLine("Opção invalida, tente novamente!");
                }
            }
            int cont = 0;
            valida = false;
            while (valida == false)
            {
                Console.WriteLine("Qual o seu continente ?");
                Console.WriteLine("1 - Americano");
                Console.WriteLine("2 - Asia");
                Console.WriteLine("3 - Áfricano");
                Console.WriteLine("4 - Europeu");
                Console.WriteLine("5 - Oceania");
                Console.WriteLine("6 - Antártida");
                cont = Convert.ToInt32(Console.ReadLine());

                if (cont == 1 || cont == 2 || cont == 3 || cont == 4 || cont == 5 || cont == 6)
                {
                    valida = true;
                }
                else
                {
                    Console.WriteLine("Opção invalida, tente novamente!");
                }
            }

            Guid continente = new Guid();

            switch (cont)
            {
                case 1:
                    continente = Guid.Parse("dec81876-9c13-ed11-b83e-000d3ac12d88");
                    break;
                case 2:
                    continente = Guid.Parse("320a012c-b113-ed11-b83e-000d3ac12d88");
                    break;
                case 3:
                    continente = Guid.Parse("eb7a1e8e-9c13-ed11-b83e-000d3ac12d88");
                    break;
                case 4:
                    continente = Guid.Parse("f2e73781-9c13-ed11-b83e-000d3ac12d88");
                    break;
                case 5:
                    continente = Guid.Parse("4b8028a7-9c13-ed11-b83e-000d3ac12d88");
                    break;
                case 6:
                    continente = Guid.Parse("ac050dae-9c13-ed11-b83e-000d3ac12d88");
                    break;
            }

            Entity conta = new Entity("account");

            conta["name"] = nome.ToString();
            conta["la_cnpj"] = cnpjconta.ToString();
            conta["telephone1"] = telefone.ToString();
            conta["emailaddress1"] = email.ToString();
            conta["la_faturamentoanual"] = new Money(faturamento);
            conta["la_portedaempresa"] = new OptionSetValue(porte);
            conta["la_continente"] = new EntityReference("la_continentes", continente);

            Guid accountId = service.Create(conta);

            valida = false;
            while (valida == false)
            {
                Console.WriteLine("Você deseja criar um contato para essa conta? (S/N)");
                string resposta = Console.ReadLine();
                string upresposta = resposta.ToUpper();

                if (upresposta == "S" || upresposta == "N")
                {

                    switch (upresposta)
                    {
                        case "S":
                            valida = true;
                            Console.WriteLine("Por favor informe o primeiro nome do contato");
                            string primeironome = Console.ReadLine();

                            Console.WriteLine("Por favor informe o segundo nome do contato");
                            string segundonome = Console.ReadLine();

                            string cpf = null;
                            valida = false;
                            while (valida == false)
                            {
                                Console.WriteLine("Qual o CPF?");
                                cpf = Console.ReadLine();
                                var v = ValidacoesLibrary.Validacoes.ValidaCPF(cpf);

                                if (v != false)
                                {
                                    valida = true;
                                }
                                else
                                {
                                    Console.WriteLine("CPF invalido, favor preencher novamente!");
                                }
                            }
                            Console.WriteLine("Qual o email do contato?");
                            string emailcontato = Console.ReadLine();

                            Console.WriteLine("Qual o cargo?");
                            string cargo = Console.ReadLine();

                            Console.WriteLine("Qual o sexo?");
                            Console.WriteLine("1 - Masculino?");
                            Console.WriteLine("2 - Feminino");
                            int sexo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Qual o seu limite de credito ?");
                            decimal limitecredito = Convert.ToDecimal(Console.ReadLine());


                            Entity contato = new Entity("contact");

                            contato["firstname"] = primeironome.ToString();
                            contato["lastname"] = segundonome.ToString();
                            contato["jobtitle"] = cargo.ToString();
                            contato["la_cpf"] = cpf.ToString();
                            contato["emailaddress1"] = emailcontato.ToString();
                            contato["gendercode"] = new OptionSetValue(sexo);
                            contato["creditlimit"] = new Money(limitecredito);
                            contato["parentcustomerid"] = new EntityReference("account", accountId);

                            service.Create(contato);
                            break;
                        case "N":
                            valida = true;
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção Invalida, tente novamente!");
                }
            }
        }
    }
}