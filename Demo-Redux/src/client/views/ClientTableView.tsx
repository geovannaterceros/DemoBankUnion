import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  styled,
  IconButton,
} from '@mui/material';
import { tableCellClasses } from '@mui/material/TableCell';
import { purpleTheme } from '../../theme/purpleTheme';
import ModeEditIcon from '@mui/icons-material/ModeEdit';
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from 'react-router-dom';
import { Client } from '../modals/Client.models';
import dayjs from 'dayjs';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { ThunkGetClient } from '~/store/client/thunks';
import { useEffect, useState } from 'react';
import PlateDialogView from '../../../src/plate/views/PlateDialogView';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: purpleTheme.palette.primary.main,
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  '&:nth-of-type(odd)': {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  '&:last-child td, &:last-child th': {
    border: 0,
  },
}));

export default function ClientTableView() {
  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  useEffect(() => {
    dispatch(ThunkGetClient());
  }, [dispatch]);

  const { clients } = useSelector((state: any) => state.client);

  // const client: Client = {
  //   clientId: 'e104a42c-d7ec-4b7e-8e8a-769cb11a481c',
  //   firstName: 'Jane',
  //   middleName: 'Doe',
  //   lastName: 'Johnson',
  //   documentType: 'Passport',
  //   identityDocument: 'ABC123456',
  //   birthDate: new Date('1985-08-20'),
  //   gender: 'Female',
  // };
  // eslint-disable-next-line react-hooks/exhaustive-deps

  //const { initialAuth } = useSelector((state: any) => state.auth);
  const navigate = useNavigate();

  const handleUpdate = (client: Client) => {
    navigate(`/client/update/${client.clientId}`);
  };

  const handleDelete = (id: string) => {
    handleOpenDialog();
    setId(id);
  };

  const [open, setOpen] = useState<boolean>(false);
  const [id, setId] = useState<string>('');
  const handleOpenDialog = () => {
    setOpen(true);
  };

  const handleCloseDialog = () => {
    setOpen(false);
  };

  const handleActionDialog = () => {
    //dispatch(ThunkDeletePlate(id));
    setOpen(false);
    navigate(`/plate`);
  };
  return (
    <>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 700 }} aria-label='customized table'>
          <TableHead>
            <TableRow>
              <StyledTableCell align='right'>Id</StyledTableCell>
              <StyledTableCell align='right'>FirstName</StyledTableCell>
              <StyledTableCell align='right'>MiddleName</StyledTableCell>
              <StyledTableCell align='right'>LastName</StyledTableCell>
              <StyledTableCell align='right'>Document Type</StyledTableCell>
              <StyledTableCell align='right'>Identity</StyledTableCell>
              <StyledTableCell align='right'>Birth Date</StyledTableCell>
              <StyledTableCell align='right'>Gender</StyledTableCell>
              <StyledTableCell align='right'>Update</StyledTableCell>
              <StyledTableCell align='right'>Delete</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {clients.map((client: Client) => (
              <StyledTableRow key={client.clientId}>
                <StyledTableCell align='right'>{client.clientId}</StyledTableCell>
                <StyledTableCell align='right'>{client.firstName}</StyledTableCell>
                <StyledTableCell align='right'>{client.middleName}</StyledTableCell>
                <StyledTableCell align='right'>{client.lastName}</StyledTableCell>
                <StyledTableCell align='right'>{client.documentType}</StyledTableCell>
                <StyledTableCell align='right'>{client.identityDocument}</StyledTableCell>
                <StyledTableCell align='right'>
                  {dayjs(client.birthDate).format('YYYY-MM-DD')}
                </StyledTableCell>
                <StyledTableCell align='right'>{client.gender}</StyledTableCell>
                <StyledTableCell align='right'>
                  <IconButton color='inherit' onClick={() => handleUpdate(client)}>
                    {' '}
                    <ModeEditIcon />
                  </IconButton>
                </StyledTableCell>
                <StyledTableCell align='right'>
                  {' '}
                  <IconButton color='inherit' onClick={() => handleDelete(client?.clientId ?? '')}>
                    {' '}
                    <DeleteIcon />
                  </IconButton>
                </StyledTableCell>
              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <PlateDialogView
        open={open}
        title={'Confirmation'}
        message='Do you want to delete this plate?'
        handleClose={handleCloseDialog}
        action={handleActionDialog}
      ></PlateDialogView>
    </>
  );
}
