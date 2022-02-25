using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using todo.app;

public class TodoService : ITodoService
{
    private readonly HttpClient httpClient;
    public TodoService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Item> GetItem()
    {
        var response = await httpClient.GetJsonAsync<Item>("Todo");
        Console.WriteLine(response);
        return response;
    }

}
