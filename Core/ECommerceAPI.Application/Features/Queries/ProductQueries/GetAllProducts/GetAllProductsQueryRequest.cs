﻿using ECommerceAPI.Application.RequestParameters;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
{
    //public Pagination Pagination { get; set; }

    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}