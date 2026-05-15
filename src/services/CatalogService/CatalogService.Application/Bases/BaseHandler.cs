using CatalogService.Application.Interfaces.AutoMapper;
using CatalogService.Application.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Bases
{
    public class BaseHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;
        public BaseHandler(IMapper _mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = _mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}
