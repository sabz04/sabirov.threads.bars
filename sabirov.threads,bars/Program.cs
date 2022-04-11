// See https://aka.ms/new-console-template for more information
using sabirov.threads_bars.Models;

Console.WriteLine("~~~Приложение запущено,введите что-нибудь~~~");
var request = Console.ReadLine();
while (request != "/exit")
{
    var msg = request;
    var req = new List<string>();
    do
    {
        Console.WriteLine("-->Введите следующий аргумент, для остановки /end");
        request = Console.ReadLine();
        if (request == "/end")
        {
            req.Add(Guid.NewGuid().ToString("D"));
            break;
        }
        if (request == "/exit")
        {
            req.Add(Guid.NewGuid().ToString("D"));
            return;
        }
        req.Add(request);
    } while (request != "/end");
    new Thread(() =>
    {
        var dummy = new DummyRequestHandler();
        var res = "";
        Console.WriteLine($"!!!Сообщение {msg} было отправлено, идентификатор: {req.Last()}");
        try
        {
             res = $"-->Сообщение с идентификатором {req.Last()} получило ответ: {dummy.HandleRequest(msg, req.ToArray())}";
            
        }
        catch(Exception ex)
        {
            res = $"-->Сообщение с идентификатором {req.Last()} упало с ошибкой: {ex.Message}";
        }
        Console.WriteLine(res);
    })
    {IsBackground = true}.Start();
    Console.WriteLine("-->Введите текст запроса, для выхода /exit");
    request = Console.ReadLine();

}










