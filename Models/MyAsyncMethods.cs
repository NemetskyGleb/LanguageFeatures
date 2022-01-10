using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models;

public class MyAsyncMethods 
{
    public static Task<long?> GetPageLength()
    {
        HttpClient client = new HttpClient();
        var httpTask = client.GetAsync("http://apress.com");
        return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) =>
        {
            return antecedent.Result.Content.Headers.ContentLength;
        });
    }
}
// Метод использует объект System.Net.Http.HttpClient для запрашивания
// содержимого домашней страницы издательства Apress
// и возвращает длину полученного содержимого.
// Работа, которая будет выполняться асинхронно представлена в .NET
// как объект Task. Объекты Task строго типизируются на основе результата,
// выдаваемого фоновой работой. Таким образом, при вызове метода HttpClient.GetAsync()
// получается объект Task<HttpResponseMessage>. Он сообщает о том, что запрос выполнится 
// в фоновом режиме и его результатом будет объект HttpResponseMessage.
// Далее идет механизм, с помощью которого указывается то, что должно
// произойти, когда фоновая задача завершится.
// Первое применение ключевого слова return указывает,
// что возвращается объект Task<HttpResponseMessage>. который при завершении
// задачи возвратит (второе ключевое слово return) длину заголовка ContentLength.
// Заголовок ContentLength возвращает значение long? (тип long, допускающий null),
//  т.е. результатом метода GetPageLength () является Task<long?>