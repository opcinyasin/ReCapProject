using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> getById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.Id==id));
        }

        public IResult Add(Rental item)
        {
            if (BusinessRules.Run(CheckReturnDate(item.CarId)) != null)
                return new ErrorResult(Messages.RentalAddedError);
            
            _rentalDal.Add(item);
            return new SuccessResult();
        }

        public IResult Update(Rental item)
        {
           _rentalDal.Update(item);
           return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental item)
        {
            _rentalDal.Delete(item);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);

            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }
    }
}
