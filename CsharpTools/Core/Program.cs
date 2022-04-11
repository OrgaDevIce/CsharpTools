using Core.Models;
using CsharpTools.Services;
using CsharpTools.Services.Interfaces;

IHttpService httpService = new HttpService();
var csvService = new CsvService();

var url = "https://www.thecolorapi.com/scheme?hex=222222";

var res = await httpService.SendHttpRequest(url, HttpMethod.Get);
var res2 = await httpService.SendHttpRequest<Root>(url, HttpMethod.Get);

Console.ReadLine();