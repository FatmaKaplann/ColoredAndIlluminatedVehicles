namespace Business;

public class Result<T>
{
    //Veriler karşılığında isteğin başarılı/başarısız olma durumu, durumun anlaşılması için mesajı ve dönen datalar için sonuç classı oluşturdum.
    public bool IsSuccessful { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
