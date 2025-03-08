import { createSlice } from '@reduxjs/toolkit';
import { createAsyncThunk } from '@reduxjs/toolkit';
import TeamService from '../services/TeamService';

const initialState = {
    team: [],
    status: 'idle',
    error: null
};

export const fetchTeamsAsync = createAsyncThunk(
    'Teams/fetchTeams',
    async () => {
      const response = await TeamService();
      return response.fetchAll();
    }
  );
  export const saveTeamsAsync = createAsyncThunk(
    'Save/saveTeams',
    async (teams) => {
      const response = await TeamService();
      return response.update(teams);
    }
  );

const teamSlice = createSlice({
    name: 'team',
    initialState,
    reducers: {
        addTeam: (state, action) => {
            state.team.push(action.payload);    
        },
        removeTeam: (state, action) => {
            state.team = state.team.filter(x => x.id !== action.payload.id);
        },
        updateTeam: (state, action) => {
            const index = state.team.findIndex(x => x.id === action.payload.id);
            if (index !== -1) {
                state.team[index] = action.payload;
            }
        }
    },  extraReducers: (builder) => {
        builder
        .addCase(fetchTeamsAsync.pending, (state) => {
            state.loading = true;
            state.error = null;
          })
          .addCase(fetchTeamsAsync.fulfilled, (state, action) => {
            state.loading = false;
            state.team = action.payload.data.data;
          })
          .addCase(fetchTeamsAsync.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error.message;
          }).addCase(saveTeamsAsync.pending, (state) => {
            state.loading = true;
            state.error = null;
          })
          .addCase(saveTeamsAsync.fulfilled, (state, action) => {
            state.loading = false;
                    alert(action.payload.data.message);
                    //useDispatch(fetchTeamsAsync());
           // state.team = action.payload.data.data;
          })
          .addCase(saveTeamsAsync.rejected, (state, action) => {
            state.loading = false;
            state.error = action.error.message;
          });
      },
});

export const { addTeam, removeTeam, updateTeam } = teamSlice.actions;

export default teamSlice.reducer;
