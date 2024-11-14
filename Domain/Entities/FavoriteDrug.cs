namespace Domain.Entities;

public class FavoriteDrug : BaseEntity<FavoriteDrug>
{
    public FavoriteDrug(
        string externalUserId,         
        Guid? drugId,
        Drug drug, 
        Guid? drugStoreId,
        DrugStore? drugStore,
        Guid? profileId,
        Profile? profile
        )
    {
        ExternalUserId = externalUserId;
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        
        // ProfileId = profileId;
        // Profile = profile;
    }
    
    public string ExternalUserId { get; private set; }
    public Drug Drug { get; private set; }
    public Guid? DrugStoreId { get; private set; }
    public DrugStore DrugStore { get; private set; }
    public Guid? DrugId { get; private set; }
    
    // public Profile Profile { get; private set; }
    // public Guid? ProfileId { get; private set; }
}