using DesignPattern_ChainOfResponsibility.DAL.Context;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfRespContext context = new ChainOfRespContext();
            if (req.Amount<=200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.Description ="Müşterinin talep ettiği tutar ödemiştir";
                customerProcess.EmployeeName = "Şube müdür yardımcısı Oğuzhan Karal";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover!=null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName= "Şube müdür yardımcısı Oğuzhan Karal";
                customerProcess.Description = "İşlem şube müdürne aktarılmıştır";
                context.CustomerProcesses.Add(customerProcess) ;
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
