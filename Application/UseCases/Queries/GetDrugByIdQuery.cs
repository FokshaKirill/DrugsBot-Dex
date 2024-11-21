﻿using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries;

/// <summary>
/// Получение сущности Drug по идентификатору запроса
/// </summary>
/// <param name="Id"></param>
public record GetDrugByIdQuery(Guid Id) : IRequest<Drug?>;