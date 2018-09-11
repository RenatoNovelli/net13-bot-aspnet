using System;
using System.Linq;
using SimpleBot.Entity.Sql;
using SimpleBot.Entity.Sql.Context;
using SimpleBot.Logic;
using SimpleBot.Logic.Interfaces;

namespace SimpleBot.Repository
{
    public class UserProfileSqlRepo : IUserProfileRepository
    {
        public UserProfile GetProfile(string id)
        {
            var userProfileDb = new UserProfileSql();

            using (var ctx = new SqlContext())
            {
                userProfileDb = ctx.UserProfile.FirstOrDefault(x => x.BotId == id);
            }

            if (userProfileDb == null)
            {
                return new UserProfile
                {
                    Id = id,
                    Visitas = 0
                };
            }

            return new UserProfile
            {
                Id = userProfileDb.BotId,
                Visitas = userProfileDb.Visitas
            };
        }

        public void SetProfile(UserProfile profile)
        {
            var userProfileDb = new UserProfileSql();


            using (var ctx = new SqlContext())
            {
                userProfileDb = ctx.UserProfile.FirstOrDefault(x => x.BotId == profile.Id);

                if (userProfileDb == null)
                {
                    ctx.UserProfile.Add(new UserProfileSql
                    {
                        BotId = profile.Id,
                        Visitas = profile.Visitas
                    });
                }
                else
                {
                    userProfileDb.Visitas = profile.Visitas;
                    ctx.Entry(userProfileDb).State = System.Data.Entity.EntityState.Modified;
                }

                ctx.SaveChanges();

            }
        }
    }
}