using ReactJs.Core.Entities;
using ReactJs.Core.Interfaces.IMapper;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Core.Interfaces.IServices;
using ReactJs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Core.Services
{
    public class ContactUsService : BaseService<ContactUs, ContactUsResponse>, IContactUsService
    {
        private readonly IBaseMapper<ContactUs, ContactUsResponse> _contactUsModelMapper;
        private readonly IBaseMapper<ContactUsRequest, ContactUs> _contactUsCreateMapper; 
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(
            IBaseMapper<ContactUs, ContactUsResponse> contactUsModelMapper,
            IBaseMapper<ContactUsRequest, ContactUs> contactUsCreateMapper,
            IContactUsRepository contactUsRepository)
            : base(contactUsModelMapper, contactUsRepository)
        {
            _contactUsCreateMapper = contactUsCreateMapper;
            _contactUsModelMapper = contactUsModelMapper;
            _contactUsRepository = contactUsRepository;
        }

        public async Task<ContactUsResponse> Create(ContactUsRequest model, CancellationToken cancellationToken)
        {
            //Mapping through AutoMapper
            var entity = _contactUsCreateMapper.MapModel(model);
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = null;
            entity.UpdatedBy = null;

            return _contactUsModelMapper.MapModel(await _contactUsRepository.Create(entity, cancellationToken));
        }
    }
}
