using SQL.Data.Entities;

namespace SQL.Data.Repository
{
    public interface IUserPreferenceRepository: IDisposable
    {
        IEnumerable<UserPreference> GetUserPreferences();
        UserPreference GetUserPreferenceByID(int userPreferenceID);
        UserPreference? GetUserPreferenceByName(string userPreferenceName);
        void InsertUserPreference(UserPreference userPreference);
        void DeleteUserPreference(UserPreference userPreference);
        void UpdateUserPreference(UserPreference userPreference);
        void Save();
    }
}