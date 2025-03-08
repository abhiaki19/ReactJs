import { configureStore } from '@reduxjs/toolkit'
import teamReducer from '../slice/TeamSlice'

const store = configureStore({
  reducer: {teamReducer},
  middleware: getDefaultMiddleware =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export default store;