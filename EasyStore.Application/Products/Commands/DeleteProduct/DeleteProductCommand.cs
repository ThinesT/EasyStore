﻿using System;
using MediatR;

namespace EasyStore.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }

    }
}
