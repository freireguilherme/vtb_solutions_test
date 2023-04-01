﻿using System.Net.Http.Json;

namespace Empresas_CRUD.Client.Services.EmpresaService
{
    //A classe Empresa Service é uma implementação da classe IEmpresaService (interface)
    public class EmpresaService : IEmpresaService
    {
        private readonly HttpClient _http;
        //construtor da classe
        public EmpresaService(HttpClient http)
        {
            _http = http;
        }
        public List<Empresas> Empresas { get; set; } = new List<Empresas>();
        public List<Segmentos> Segmentos { get; set; } = new List<Segmentos>();

        public async Task GetEmpresas()
        {
            var resultado = await _http.GetFromJsonAsync<List<Empresas>>("api/empresas");

            if (resultado != null)
                Empresas = resultado;
        }

        public async Task GetSegmentos()
        {
            var resultado = await _http.GetFromJsonAsync<List<Segmentos>>("api/empresas/segmentos");

            if (resultado != null)
                Segmentos = resultado;
        }

        public async Task<Empresas> GetSingleEmpresa(int id)
        {
            var resultado = await _http.GetFromJsonAsync<Empresas>($"api/empresas/{id}");

            if (resultado != null)
                return resultado;
            throw new Exception("Empresa não encontada");
        }
    }
}
