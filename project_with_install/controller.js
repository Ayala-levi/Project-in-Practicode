import renderApi from '@api/render-api';

const funcs = {
    getAll: async (req, res) => {
        renderApi.auth('rnd_lVFPbXqkEVHYTyqKwidsTtakBBXg');
        const { data } = await renderApi.listServices({ includePreviews: 'true', limit: '20' })
            .then(({ data }) => res.json(data))
            .catch(err => console.error(err));
    }
}
export default funcs    