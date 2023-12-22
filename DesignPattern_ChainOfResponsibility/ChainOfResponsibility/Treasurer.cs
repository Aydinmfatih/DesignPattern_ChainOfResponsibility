using DesignPattern_ChainOfResponsibility.DAL.Context;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfRespContext context = new ChainOfRespContext();
            if (req.Amount<=100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.EmployeeName = req.EmployeeName;
                customerProcess.Name = "Veznedar Berkan Baytar";
                customerProcess.Description = "Müşterinin tale ettiği kredi tutarı tarafınca ödenmiştir"; 
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover!=null)
            {
                CustomerProcess customerProcess= new CustomerProcess();
                customerProcess.Amount=req.Amount;
                customerProcess.Name=req.EmployeeName;
                customerProcess.EmployeeName="Veznedar Berkan Baytar";
                customerProcess.Description="Müşterinin talep ettiği tutar tarafınca ödenmediği için işlem şube müdür yardımcısına akktarılmıştır";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
                
            }
        }
    }
}
