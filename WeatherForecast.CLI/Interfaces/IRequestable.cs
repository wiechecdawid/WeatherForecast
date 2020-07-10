using System;
using System.Threading.Tasks;
///<sumary>
/// Represents options used in order to send requests to the API
///</sumary>
public interface IRequestable<T> where T:class
{
    T Instance { get; set; }
    Task<Func<string, string, T>> GetResponse();
}