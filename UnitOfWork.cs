using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KFP.DATA;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KFP.DATA
{
    public class UnitOfWork : IDisposable
    {
        private KFG_Db context = new KFG_Db();
        private GenericRepository<MembershipPackages> membershipRepository;
        private GenericRepository<KlassType> KlassTypeRepository;
        private GenericRepository<BankingDetails> BankingRepository;
        private GenericRepository<KlassVenue> VenueRepository;
        private GenericRepository<Equipment_Type> EquipTypeRepository;
        private GenericRepository<Equipment> EquipmentRepository;
        private GenericRepository<PT_Category> PTCatRepository;
        private GenericRepository<PersonalTrainor> PersonalTrainorRepository;
        private GenericRepository<Klass> KlassRepository;
        private GenericRepository<Booking> bookingRepository;
        private GenericRepository<IdentityRole> roleRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<Instructor> instructorRepository;
        public GenericRepository<Instructor> instructorRepositorys
        {
            get
            {

                if (this.instructorRepository == null)
                {
                    this.instructorRepository = new GenericRepository<Instructor>(context);
                }
                return instructorRepository;
            }
        }
        public GenericRepository<Client> clientRepositorys
        {
            get
            {

                if (this.clientRepository == null)
                {
                    this.clientRepository = new GenericRepository<Client>(context);
                }
                return clientRepository;
            }
        }
        public GenericRepository<User> userRepositorys
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public GenericRepository<IdentityRole> roleRepositorys
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<IdentityRole>(context);
                }
                return roleRepository;
            }
        }
        public GenericRepository<Booking> bookingRepositorys
        {
            get
            {

                if (this.bookingRepository == null)
                {
                    this.bookingRepository = new GenericRepository<Booking>(context);
                }
                return bookingRepository;
            }
        }
        public GenericRepository<MembershipPackages> membershipRepositorys
        {
            get
            {

                if (this.membershipRepository == null)
                {
                    this.membershipRepository = new GenericRepository<MembershipPackages>(context);
                }
                return membershipRepository;
            }
        }
        public GenericRepository<KlassType> KlassTypeRepositorys
        {
            get
            {

                if (this.KlassTypeRepository == null)
                {
                    this.KlassTypeRepository = new GenericRepository<KlassType>(context);
                }
                return KlassTypeRepository;
            }
        }
        public GenericRepository<BankingDetails> bankingRepositorys
        {
            get
            {

                if (this.BankingRepository == null)
                {
                    this.BankingRepository = new GenericRepository<BankingDetails>(context);
                }
                return BankingRepository;
            }
        }
        public GenericRepository<KlassVenue> VenueRepositorys
        {
            get
            {

                if (this.VenueRepository == null)
                {
                    this.VenueRepository = new GenericRepository<KlassVenue>(context);
                }
                return VenueRepository;
            }
        }
        public GenericRepository<Equipment_Type> EquipTypeRepositorys
        {
            get
            {

                if (this.EquipTypeRepository == null)
                {
                    this.EquipTypeRepository = new GenericRepository<Equipment_Type>(context);
                }
                return EquipTypeRepository;
            }
        }

        public GenericRepository<Equipment> EquipmentRepositorys
        {
            get
            {

                if (this.EquipmentRepository == null)
                {
                    this.EquipmentRepository = new GenericRepository<Equipment>(context);
                }
                return EquipmentRepository;
            }
        }
        public GenericRepository<PT_Category> PTCatRepositorys
        {
            get
            {

                if (this.PTCatRepository == null)
                {
                    this.PTCatRepository = new GenericRepository<PT_Category>(context);
                }
                return PTCatRepository;
            }
        }
        public GenericRepository<PersonalTrainor> PersonalTrainorRepositorys
        {
            get
            {

                if (this.PersonalTrainorRepository == null)
                {
                    this.PersonalTrainorRepository = new GenericRepository<PersonalTrainor>(context);
                }
                return PersonalTrainorRepository;
            }
        }
        public GenericRepository<Klass> KlassRepositorys
        {
            get
            {

                if (this.KlassRepository == null)
                {
                    this.KlassRepository = new GenericRepository<Klass>(context);
                }
                return KlassRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}

