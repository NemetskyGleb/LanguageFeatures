using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models;

public class MyAsyncMethods 
{
    public async static Task<long?> GetPageLength()
    {
        HttpClient client = new HttpClient();
        var httpMessage = await client.GetAsync("http://apress.com");
        return httpMessage.Content.Headers.ContentLength;
    }
}
// Ключевое слово await используется при вызове асинхронного метода. 
// Оно сообщает компилятору С# о том, что необходимо подождать результата Task, 
// который возвращается методом GetAsync(),
// и затем заняться выполнением остальных операторов в том же методе.
// Применение ключевого слова await означает, что мы можем трактовать результат
// метода GetAsync().как если бы он был обычным методом, 
// и просто присвоить возвращаемый им объект HttpResponseMessage какой-нибудь переменной.
// Еще лучше то, что затем можно использовать ключевое слово return традиционным образом для
// выдачи результата из другого метода - значения свойства ContentLength в данном
// случае.
// При использовании ключевого слова await потребуется также добавить к сигнатуре метода ключевое слово async