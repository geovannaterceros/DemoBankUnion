import { AnyAction } from 'redux';
import { ThunkAction } from 'redux-thunk';
import { RootState } from '~/store';
import {
  /* deletePlate,*/ getClient /*, getPlateId*/,
  saveNewClient /*updatePlate */,
} from './clientSlice';
import { clientApi } from '~/api/clientApi';
import { Client } from '~/client/modals/Client.models';

export const ThunkGetClient = (): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await clientApi.get(`/Client`);
    return dispatch(
      getClient({
        isLoading: false,
        clients: data,
      }),
    );
  };
};

export const ThunkPostClient = (
  client: Client,
): ThunkAction<void, RootState, unknown, AnyAction> => {
  return async (dispatch) => {
    const { data } = await clientApi.post(`/Client`, client);
    dispatch(
      saveNewClient({
        isLoading: false,
        client: data,
      }),
    );
  };
};

// export const ThunkDeletePlate = (id: any): ThunkAction<void, RootState, unknown, AnyAction> => {
//   return async (dispatch) => {
//     const { data } = await plateApi.delete(`/Plates/` + id);
//     dispatch(
//       deletePlate({
//         isLoading: false,
//         plate: data,
//       }),
//     );
//   };
// };

// export const ThunkUpdatePlate = (
//   id: any,
//   plate: Plate,
// ): ThunkAction<void, RootState, unknown, AnyAction> => {
//   return async (dispatch) => {
//     const { data } = await plateApi.put(`/Plates/` + id, plate);
//     dispatch(
//       updatePlate({
//         isLoading: true,
//         plate: data,
//       }),
//     );
//   };
// };

// export const ThunkGetPlateId = (id: any): ThunkAction<void, RootState, unknown, AnyAction> => {
//   return async (dispatch) => {
//     const { data } = await plateApi.get(`/Plates/` + id);
//     dispatch(
//       getPlateId({
//         isLoading: false,
//         plate: data,
//       }),
//     );
//   };
// };
