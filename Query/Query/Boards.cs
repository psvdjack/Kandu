﻿using System.Collections.Generic;

namespace Kandu.Query
{
    public class Boards : QuerySql
    {
        public Boards(string connectionString) : base(connectionString)
        {
        }

        public int CreateBoard(Models.Board board)
        {
            return Sql.ExecuteScalar<int>(
                "Board_Create",
                new Dictionary<string, object>()
                {
                    {"teamId", board.teamId },
                    {"favorite", board.favorite },
                    {"name", board.name },
                    {"security", board.security },
                    {"color", board.color }
                }
            );
        }

        public Models.Board GetBoardDetails(int boardId)
        {
            var list = Sql.Populate<Models.Board>(
                "Board_GetDetails",
                new Dictionary<string, object>()
                {
                    {"boardId", boardId }
                }
            );
            if(list.Count > 0) { return list[0]; }
            return null;
        }

        public List<Models.Board> GetList(int userId)
        {
            return Sql.Populate<Models.Board>(
                "Boards_GetList",
                new Dictionary<string, object>()
                {
                    {"userId", userId }
                }
            );
        }
    }
}