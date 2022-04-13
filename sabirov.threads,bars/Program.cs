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
            break;
        }
        if (request == "/exit")
        {
            return;
        }
        req.Add(request);
    } while (request != "/end");
    ThreadPool.QueueUserWorkItem(callBack =>
    {
        var dummy = new DummyRequestHandler();
        var res = "";
        var ident = Guid.NewGuid().ToString("D");
        Console.WriteLine($"!!!Сообщение {msg} было отправлено, идентификатор: {ident}");
        try
        {
            res = $"-->Сообщение с идентификатором {ident} получило ответ: {dummy.HandleRequest(msg, req.ToArray())}";
        }
        catch (Exception ex)
        {
            res = $"-->Сообщение с идентификатором {ident} упало с ошибкой: {ex.Message}";
        }
        Console.WriteLine(res);
    });
    Console.WriteLine("-->Введите текст запроса, для выхода /exit");
    request = Console.ReadLine();

}










