using Application.Exceptions;
using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands;

/// <summary>
/// 
/// </summary>
public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Drug?>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// 
    /// </summary>
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="drugWriteRepository"></param>
    /// <param name="drugReadRepository"></param>
    public CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,
        IDrugReadRepository drugReadRepository)
    {
        _drugWriteRepository = drugWriteRepository;
        _drugReadRepository = drugReadRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="DrugAlreadyExistsException"></exception>
    public async Task<Drug?> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var existingDrug = await _drugReadRepository.GetQueryableAsync(null, cancellationToken);
        if (existingDrug.Any(d => d.Name == request.Name))
        {
            throw new DrugAlreadyExistsException();
        }

        var drug = new Drug(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);

        await _drugWriteRepository.AddAsync(drug, cancellationToken);

        return drug;
    }
}