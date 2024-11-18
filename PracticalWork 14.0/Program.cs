using BankSystemExceptions;

namespace PracticalWork_14._0
{
    public class Program
    {
        static void Main(string[] args)
        {
            var depositAccount = new DepositAccount("123-456");
            var nonDepositAccount = new NonDepositAccount("789-012");

            try
            {
                depositAccount.Deposit(1000);
                depositAccount.LogAction("Депозит 1000");

                // Перевод средств
                depositAccount.TransferTo(nonDepositAccount, 500);
                nonDepositAccount.LogAction("Получение 500");

                // Пробуем снять деньги с депозитного счета
                depositAccount.Withdraw(200);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidTransferException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
