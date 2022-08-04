using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWork
{
    public class Conexão
    {
        public static IOrganizationService GetService()
        {
             string connectionString =
                           "AuthType=OAuth;" +
                           "Username=admin@mywork1.onmicrosoft.com;" +
                           "Password=Wpote8604#;" +
                           "Url=https://myworkla.crm2.dynamics.com/;" +
                           "AppId=c11c817c-5085-41d4-98ce-cdca23147396;" +
                           "RedirectUri=app://58145B91-0C36-4500-8554-080854F2AC97;";

              CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
              return crmServiceClient.OrganizationWebProxyClient;


         }

    }
}
