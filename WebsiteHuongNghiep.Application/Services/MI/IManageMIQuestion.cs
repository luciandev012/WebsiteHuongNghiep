using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteHuongNghiep.Data.Entities;

namespace WebsiteHuongNghiep.Application.Services.MI
{
    public interface IManageMIQuestion
    {
        Task<int> Create(MIQuestion request);
        Task<int> Edit(MIQuestion request);
        Task<int> Delete(int id);
        Task<List<MIQuestion>> GetAll(string keyword);
        Task<MIQuestion> GetById(int id);
        //Task<List<MITable>> GetByTable(int tableId);
        Task<int> Execute(int[] score, int[] tableId);
    }
}
