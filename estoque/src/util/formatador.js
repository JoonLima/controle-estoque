import moment from 'moment';

function formatarData(data) {
  return moment(data).locale('pt-br').format('DD/MM/YYYY');
}

export default {
  formatarData,
};
