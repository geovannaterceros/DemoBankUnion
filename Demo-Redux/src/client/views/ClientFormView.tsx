import { Button, Grid, MenuItem, TextField } from '@mui/material';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import dayjs from 'dayjs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { useNavigate } from 'react-router-dom';
// import { Plate } from '../modals/Plate.models';
import useForm from '~/hooks/useForm';
import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { ThunkPostPlate, ThunkUpdatePlate } from '~/store/plate/thunks';
// import { offers } from '../modals/OfferList.models';
import { Client } from '../modals/Client.models';
import { documentType } from '../modals/DocumentType.models';
import { gender } from '../modals/Gender.models';
import { ThunkPostClient } from '~/store/client/thunks';

interface Props {
  client?: Client;
}

export default function ClientFormView(props: Props) {
  const { client } = props;
  const navigate = useNavigate();
  const { firstName, middleName, lastName, identityDoc, onInputChange } = useForm({
    firstName: client?.firstName ?? '',
    middleName: client?.middleName ?? '',
    lastName: client?.lastName ?? '',
    identityDoc: client?.identityDocument ?? '',
  });

  const [selectedDate, setSelectedDate] = useState<any | null>(dayjs(client?.birthDate));
  const [selectedDocumentType, setSelectedDocumentType] = useState<string>(() => {
    if (client?.documentType === 'DNI') {
      return 'DNI';
    } else if (client?.documentType === 'CI') {
      return 'CI';
    } else {
      return 'Passport';
    }
  });
  const [selectedGender, setSelectedGender] = useState<string>(client?.gender ? 'Female' : 'Male');

  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  // const { initialAuth } = useSelector((state: RootState) => state.client);

  const onSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    // if (client !== undefined) {
    //   const plateUpdate: Client = {
    //     id: plate.id,
    //     name: name,
    //     dateActivity: new Date(selectedDate),
    //     offer: selectedOffer === 'true',
    //   };
    //   dispatch(ThunkUpdatePlate(plate.id, plateUpdate));
    // } else {
    const clientCreated: Client = {
      firstName: firstName,
      middleName: middleName,
      lastName: lastName,
      documentType: selectedDocumentType,
      identityDocument: identityDoc,
      birthDate: new Date(selectedDate),
      gender: selectedGender,
      //offer: selectedOffer === 'true',
    };
    console.log(clientCreated);
    dispatch(ThunkPostClient(clientCreated));
    //}

    navigate('/client');
  };

  return (
    <form aria-label='submit-form' onSubmit={onSubmit}>
      <Grid container>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-basic'
            type='text'
            placeholder='FirstName'
            fullWidth
            name='firstName'
            value={firstName}
            onChange={onInputChange}
          />
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-basic'
            type='text'
            placeholder='MiddleName'
            fullWidth
            name='middleName'
            value={middleName}
            onChange={onInputChange}
          />
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-basic'
            type='text'
            placeholder='LastName'
            fullWidth
            name='lastName'
            value={lastName}
            onChange={onInputChange}
          />
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-select-currency'
            select
            label='Document Type'
            value={selectedDocumentType}
            fullWidth
            name='documentType'
            onChange={(event) => setSelectedDocumentType(event.target.value)}
          >
            {documentType.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </TextField>
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-basic'
            type='text'
            placeholder='Document'
            fullWidth
            name='identityDoc'
            value={identityDoc}
            onChange={onInputChange}
          />
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DatePicker
              label='Birth Day'
              defaultValue={dayjs(dayjs(selectedDate).format('YYYY-MM-DD'))}
              onChange={(date: any | null) => setSelectedDate(date)}
              sx={{ width: '100%' }}
            />
          </LocalizationProvider>
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-select-currency'
            select
            label='Gender'
            value={selectedGender}
            fullWidth
            name='gender'
            onChange={(event) => setSelectedGender(event.target.value)}
          >
            {gender.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </TextField>
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <Button variant='contained' type='submit' fullWidth>
            {' '}
            Save{' '}
          </Button>
        </Grid>
      </Grid>
    </form>
  );
}
