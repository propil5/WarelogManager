using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;

namespace WarelogManager.Model.Services.Warehouse
{
    public class ProductImageService
    {
        //private readonly IProductImageRepository _productImageRepository;
        //private readonly IUnitOfWork _unitOfWork;

        //public CompanyService(IProductImageRepository productImageRepository, IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //public async Task<DtoResponse> Add(CompanyDto company)
        //{
        //    try
        //    {
        //        var id = await _companyRepository.Add(company);

        //        company.Id = id ?? 0;
        //        return new DtoResponse(company);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new DtoResponse($"An error occurred when saving the product do the database: {ex.Message}");
        //    }
        //}

        //public async Task<IEnumerable<CompanyDto>> Get()
        //{
        //    return await _companyRepository.Get();
        //}

        //public async Task<CompanyDto> Get(int id)
        //{
        //    return await _companyRepository.GetById(id);
        //}

        //public async Task<DtoResponse> Update(int id, CompanyDto company)
        //{
        //    var existingCompany = await _companyRepository.GetById(id);

        //    if (existingCompany == null)
        //    {
        //        return new DtoResponse($"Could not find company to update with id:{id}.");
        //    }

        //    existingCompany.AddresId = company.AddresId;
        //    existingCompany.Name = company.Name;

        //    try
        //    {
        //        _companyRepository.Update(company);
        //        await _unitOfWork.CompleteAsync();

        //        return new DtoResponse(company);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new DtoResponse($"An error occurred when saving the company: {ex.Message}");
        //    }
        //}

        //public async Task<DtoResponse> DeleteAsync(int id)
        //{
        //    var existingCompany = await _companyRepository.GetById(id);

        //    if (existingCompany == null)
        //    {
        //        return new DtoResponse($"Could not find company to update with id: {id}.");
        //    }

        //    try
        //    {
        //        _companyRepository.Delete(existingCompany);
        //        await _unitOfWork.CompleteAsync();

        //        return new DtoResponse(existingCompany);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new DtoResponse($"An error occurred when deleting company. {ex.Message}");
        //    }
        //}
    }
}
