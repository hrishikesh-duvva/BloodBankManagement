using BloodBankManagement.Models;

namespace BloodBankManagement.Services
{
    public class BloodBankService
    {
        private readonly List<BloodBankEntry> _bloodBankEntries;

        public BloodBankService()
        {
            _bloodBankEntries = new List<BloodBankEntry>();
        }

        public List<BloodBankEntry> GetAll() => _bloodBankEntries;

        public BloodBankEntry GetById(Guid id) =>
            _bloodBankEntries.FirstOrDefault(entry => entry.Id == id);

        public void Add(BloodBankEntry entry)
        {
            entry.Id = Guid.NewGuid();
            _bloodBankEntries.Add(entry);
        }

        public void Update(Guid id, BloodBankEntry updatedEntry)
        {
            var entry = GetById(id);
            if (entry != null)
            {
                entry.DonorName = updatedEntry.DonorName;
                entry.Age = updatedEntry.Age;
                entry.BloodType = updatedEntry.BloodType;
                entry.ContactInfo = updatedEntry.ContactInfo;
                entry.Quantity = updatedEntry.Quantity;
                entry.CollectionDate = updatedEntry.CollectionDate;
                entry.ExpirationDate = updatedEntry.ExpirationDate;
                entry.Status = updatedEntry.Status;
            }
        }

        public void Delete(Guid id)
        {
            var entry = GetById(id);
            if (entry != null)
                _bloodBankEntries.Remove(entry);
        }

        public IEnumerable<BloodBankEntry> SearchByName(string donorName) =>
         _bloodBankEntries.Where(entry =>
             (string.IsNullOrEmpty(donorName) || entry.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase)));

        public IEnumerable<BloodBankEntry> SearchByBloodType(string bloodType) =>
            _bloodBankEntries.Where(entry =>
                (string.IsNullOrEmpty(bloodType) || entry.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase)));

        public IEnumerable<BloodBankEntry> SearchByStatus(string status) =>
            _bloodBankEntries.Where(entry =>
                (string.IsNullOrEmpty(status) || entry.Status.Equals(status, StringComparison.OrdinalIgnoreCase)));

        public IEnumerable<BloodBankEntry> Search(string donorName, string bloodType, string status) =>
            _bloodBankEntries.Where(entry =>
                (string.IsNullOrEmpty(donorName) || entry.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(bloodType) || entry.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(status) || entry.Status.Equals(status, StringComparison.OrdinalIgnoreCase)));

        //public IEnumerable<BloodBankEntry> GetSorted(string sortBy, string sortOrder)
        //{
        //    var query = _bloodBankEntries.AsQueryable();

        //    // sorting based on the sortBy parameter
        //    query = sortBy?.ToLower() switch
        //    {
        //        "bloodtype" => sortOrder?.ToLower() == "desc"
        //            ? query.OrderByDescending(entry => entry.BloodType)
        //            : query.OrderBy(entry => entry.BloodType),
        //        "collectiondate" => sortOrder?.ToLower() == "desc"
        //            ? query.OrderByDescending(entry => entry.CollectionDate)
        //            : query.OrderBy(entry => entry.CollectionDate),
        //        _ => query // No sorting if invalid sortBy is provided
        //    };

        //    return query.ToList();
        //}

    }
}
