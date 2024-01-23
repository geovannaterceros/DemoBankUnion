import { createSlice } from '@reduxjs/toolkit';
import type { PayloadAction } from '@reduxjs/toolkit';
import { Client } from '~/client/modals/Client.models';

interface ClientState {
  isLoading: boolean;
  clients?: Client[];
  client?: Client | null;
}

const initialState: ClientState = {
  isLoading: false,
  clients: [],
  client: null,
};

export const clientSlice = createSlice({
  name: 'client',
  initialState,
  reducers: {
    getClient: (state, action: PayloadAction<ClientState>) => {
      state.isLoading = false;
      state.clients = action.payload.clients;
    },
    // getPlateId: (state, action: PayloadAction<PlateState>) => {
    //   state.isLoading = false;
    //   state.plate = action.payload.plate;
    // },
    saveNewClient: (state, action: PayloadAction<ClientState>) => {
      state.isLoading = false;
      state.client = action.payload.client;
    },
    // deletePlate: (state, action: PayloadAction<PlateState>) => {
    //   state.isLoading = false;
    //   state.plate = action.payload.plate;
    // },
    // updatePlate: (state, action: PayloadAction<PlateState>) => {
    //   state.isLoading = action.payload.isLoading;
    //   state.plate = action.payload.plate;
    // },
  },
});

export const { getClient, saveNewClient /*, getPlateId, saveNewPlate, deletePlate, updatePlate*/ } =
  clientSlice.actions;

export default clientSlice.reducer;
